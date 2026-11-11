import React, { useEffect, useRef } from 'react';
import { CartIcon } from '../../assets/icons/CartIcon';
import { TrainIcon } from '../../assets/icons/TrainIcon';

// Animation constants (speed, spacing, and train composition)
// SPEED is in SVG units per frame, CART_SPACING in SVG user units (pixels), and NUMBER_OF_CARTS defines trailing carts
const SPEED = 0.5;
const CART_SPACING = 45;
const NUMBER_OF_CARTS = 3;

interface SmokeParticle {
    x: number;
    y: number;
    size: number;
    opacity: number;
}

export const TrainTrackAnimation: React.FC = () => {
    // DOM references for the SVG elements, including the path, train, carts, and smoke group
    // DOM references are used to manipulate the SVG elements directly for animation
    const pathRef = useRef<SVGPathElement>(null);
    const trainRef = useRef<SVGGElement>(null);
    const cartRefs = useRef<(SVGGElement | null)[]>([]);
    const smokeGroupRef = useRef<SVGGElement>(null);

    useEffect(() => {
        const path = pathRef.current;
        if (!path) return;

        // Path and train sequence dimensions, length is calculated based on the number of carts and their spacing
        // Measured in internal SVG user units (pixels based on viewBox)
        const pathLength = path.getTotalLength();
        const totalTrainLength = (NUMBER_OF_CARTS * CART_SPACING) + 40;
        const maxDistance = pathLength + totalTrainLength;

        let progress = 0;
        let animId: number;

        let particles: SmokeParticle[] = [];
        let frameCounter = 0;

        // Length of opacity fade-in/fade-out zones at path ends
        const fadeZoneLength = 50;

        const animate = () => {
            // Update animation progress and loop seamlessly
            progress = (progress + SPEED) % maxDistance;

            // Reset smoke particles when the loop starts over
            if (progress < SPEED) {
                particles = [];
            }

            // Train
            if (progress <= pathLength) {
                const pointTrain = path.getPointAtLength(progress);
                const pointTrainAhead = path.getPointAtLength(Math.min(progress + 1, pathLength));
                const angleTrain = Math.atan2(
                    pointTrainAhead.y - pointTrain.y,
                    pointTrainAhead.x - pointTrain.x
                ) * (180 / Math.PI);

                // Calculate opacity fade-in/fade-out at start and end of path
                let trainOpacity = 1;
                if (progress < fadeZoneLength) {
                    trainOpacity = progress / fadeZoneLength;
                } else if (progress > pathLength - fadeZoneLength) {
                    trainOpacity = (pathLength - progress) / fadeZoneLength;
                }

                // Update train position, rotation, and opacity
                if (trainRef.current) {
                    trainRef.current.style.display = 'block';
                    trainRef.current.style.opacity = trainOpacity.toString();
                    trainRef.current.setAttribute(
                        'transform',
                        `translate(${pointTrain.x}, ${pointTrain.y}) rotate(${angleTrain})`
                    );
                }

                // Smoke
                frameCounter++;
                if (frameCounter % 35 === 0) {
                    const rad = (angleTrain * Math.PI) / 180;

                    // Chimney position offset relative to engine center
                    const localX = 6;
                    const localY = -22;

                    // Convert chimney offset to global SVG coordinates based on engine angle
                    const globalChimneyX = pointTrain.x + (localX * Math.cos(rad) - localY * Math.sin(rad));
                    const globalChimneyY = pointTrain.y + (localX * Math.sin(rad) + localY * Math.cos(rad));

                    // Spawn a new smoke particle at the chimney position with initial size and opacity
                    particles.push({
                        x: globalChimneyX,
                        y: globalChimneyY,
                        size: 3.5,
                        opacity: 0.95 * trainOpacity
                    });
                }
            } else if (trainRef.current) {
                // Hide engine when it reaches the end of the path
                trainRef.current.style.display = 'none';
            }

            // Smoke puff animation
            if (smokeGroupRef.current) {
                smokeGroupRef.current.innerHTML = '';

                for (let i = particles.length - 1; i >= 0; i--) {
                    const p = particles[i];

                    // Rise, expand, and fade out smoke
                    p.y -= 0.50;
                    p.x -= 0.01;
                    p.size += 0.14;
                    p.opacity -= 0.020;

                    if (p.opacity <= 0) {
                        particles.splice(i, 1);
                        continue;
                    }

                    // Create and append a new SVG circle for the smoke particle
                    // The DOM is the browser's live element tree. Here we inject SVG circle nodes directly for fast rendering
                    const circle = document.createElementNS('http://www.w3.org/2000/svg', 'circle');
                    circle.setAttribute('cx', p.x.toString());
                    circle.setAttribute('cy', p.y.toString());
                    circle.setAttribute('r', p.size.toString());
                    circle.setAttribute('fill', '#94A3B8');
                    circle.setAttribute('opacity', p.opacity.toString());
                    smokeGroupRef.current.appendChild(circle);
                }
            }

            // Carts
            cartRefs.current.forEach((cartEl, index) => {
                if (!cartEl) return;

                // Offset each cart behind the engine
                const cartOffset = (index + 1) * CART_SPACING;
                const cartProgress = progress - cartOffset;

                if (cartProgress >= 0 && cartProgress <= pathLength) {
                    cartEl.style.display = 'block';

                    // Calculate opacity for carts based on their position along the path
                    let cartOpacity = 1;
                    if (cartProgress < fadeZoneLength) {
                        cartOpacity = cartProgress / fadeZoneLength;
                    } else if (cartProgress > pathLength - fadeZoneLength) {
                        cartOpacity = (pathLength - cartProgress) / fadeZoneLength;
                    }
                    cartEl.style.opacity = cartOpacity.toString();

                    // Calculate position and rotation angle for current cart
                    const pointCart = path.getPointAtLength(cartProgress);
                    const pointCartAhead = path.getPointAtLength(Math.min(cartProgress + 1, pathLength));
                    const angleCart = Math.atan2(
                        pointCartAhead.y - pointCart.y,
                        pointCartAhead.x - pointCart.x
                    ) * (180 / Math.PI);

                    // Update cart transform attribute to position and rotate the cart along the path
                    cartEl.setAttribute(
                        'transform',
                        `translate(${pointCart.x}, ${pointCart.y}) rotate(${angleCart})`
                    );
                } else {
                    // Hide carts that are off the path
                    cartEl.style.display = 'none';
                }
            });

            // Start animation loop for the next frame
            animId = requestAnimationFrame(animate);
        };

        animId = requestAnimationFrame(animate);

        // Cleanup animation frame on unmount
        return () => cancelAnimationFrame(animId);
    }, []);

    return (
        <div className="w-full flex justify-center items-center">
            <svg viewBox="0 0 500 140" className="w-full max-w-md h-auto overflow-visible">
                {/* Track path */}
                <path
                    ref={pathRef}
                    d="M 0 130 Q 125 30 250 120 T 500 120"
                    fill="none"
                    stroke="#4A5568"
                    strokeWidth="3"
                    strokeDasharray="6 5"
                />

                {/* Train carts */}
                {Array.from({ length: NUMBER_OF_CARTS }).map((_, index) => (
                    <g
                        key={index}
                        ref={(el) => { cartRefs.current[index] = el; }}
                    >
                        <g transform="translate(-20, -25)">
                            <CartIcon width={40} height={40} />
                        </g>
                    </g>
                ))}

                {/* Train locomotive */}
                <g ref={trainRef}>
                    <g transform="translate(-20, -25)">
                        <TrainIcon width={40} height={40} />
                    </g>
                </g>

                {/* Smoke */}
                <g ref={smokeGroupRef} />
            </svg>
        </div>
    );
};