import "../message/StaticMessage.css";

type MessageProps = {
    message: string;
    type: "error" | "success" | "info" | "warning";
};

export default function StaticMessage({ message, type }: MessageProps) {
    return (
        <div className={`error-message ${type}`}>
            <p className="message">{message}</p>
        </div>
    );
}