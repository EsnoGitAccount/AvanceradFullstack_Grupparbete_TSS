import React, { useEffect, useRef } from 'react';
import { CartIcon } from '../../assets/icons/CartIcon';
import { TrainIcon } from '../../assets/icons/TrainIcon';

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
    const pathRef = useRef<SVGPathElement>(null);
    const trainRef = useRef<SVGGElement>(null);
    const cartRefs = useRef<(SVGGElement | null)[]>([]);
    const smokeGroupRef = useRef<SVGGElement>(null);

    useEffect(() => {
        const path = pathRef.current;
        if (!path) return;

        const pathLength = path.getTotalLength();
        const totalTrainLength = (NUMBER_OF_CARTS * CART_SPACING) + 40;
        const maxDistance = pathLength + totalTrainLength;

        let progress = 0;
        let animId: number;

        let particles: SmokeParticle[] = [];
        let frameCounter = 0;

        // Define the length of the fade zones for both the train and carts
        const fadeZoneLength = 50;

        const animate = () => {
            progress = (progress + SPEED) % maxDistance;

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

                let trainOpacity = 1;
                if (progress < fadeZoneLength) {
                    trainOpacity = progress / fadeZoneLength;
                } else if (progress > pathLength - fadeZoneLength) {
                    trainOpacity = (pathLength - progress) / fadeZoneLength;
                }

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

                    const localX = 6;
                    const localY = -22;

                    const globalChimneyX = pointTrain.x + (localX * Math.cos(rad) - localY * Math.sin(rad));
                    const globalChimneyY = pointTrain.y + (localX * Math.sin(rad) + localY * Math.cos(rad));

                    particles.push({
                        x: globalChimneyX,
                        y: globalChimneyY,
                        size: 3.5,
                        opacity: 0.95 * trainOpacity
                    });
                }
            } else if (trainRef.current) {
                trainRef.current.style.display = 'none';
            }

            // Smoke puff animation
            if (smokeGroupRef.current) {
                smokeGroupRef.current.innerHTML = '';

                for (let i = particles.length - 1; i >= 0; i--) {
                    const p = particles[i];

                    p.y -= 0.50;
                    p.x -= 0.01;
                    p.size += 0.14;
                    p.opacity -= 0.020;

                    if (p.opacity <= 0) {
                        particles.splice(i, 1);
                        continue;
                    }

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

                    const pointCart = path.getPointAtLength(cartProgress);
                    const pointCartAhead = path.getPointAtLength(Math.min(cartProgress + 1, pathLength));
                    const angleCart = Math.atan2(
                        pointCartAhead.y - pointCart.y,
                        pointCartAhead.x - pointCart.x
                    ) * (180 / Math.PI);

                    cartEl.setAttribute(
                        'transform',
                        `translate(${pointCart.x}, ${pointCart.y}) rotate(${angleCart})`
                    );
                } else {
                    cartEl.style.display = 'none';
                }
            });

            animId = requestAnimationFrame(animate);
        };

        animId = requestAnimationFrame(animate);

        return () => cancelAnimationFrame(animId);
    }, []);

    return (
        <div className="w-full flex justify-center items-center">
            <svg viewBox="0 0 500 140" className="w-full max-w-md h-auto overflow-visible">
                <path
                    ref={pathRef}
                    d="M 0 130 Q 125 30 250 120 T 500 120"
                    fill="none"
                    stroke="#4A5568"
                    strokeWidth="3"
                    strokeDasharray="6 5"
                />

                {/* Carts */}
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

                {/* Train */}
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