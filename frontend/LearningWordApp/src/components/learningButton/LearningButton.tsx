import { ReactNode } from "react";
import styles from "./LearningButton.module.scss";

type LeaningButtonType = "positive" | "negative";

type LearningButtonProps = {
  children?: ReactNode;
  onClick: () => void;
  type: LeaningButtonType;
};

export const LearningButton = ({ children, onClick, type }: LearningButtonProps) => {
  const className = type == "positive" ? "button-positive" : "button-negative";

  return (
    <button
      className={styles[className]}
      onClick={() => {
        onClick();
      }}
    >
      <div className={styles["button-content"]}>{children}</div>
    </button>
  );
};
