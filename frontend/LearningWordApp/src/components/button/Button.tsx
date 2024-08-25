import { ReactNode } from "react";
import styles from "./Button.module.scss";

type ButtonType = "default" | "delete" | "link";

type BackButtonProps = {
  children?: ReactNode;
  onClick: () => void;
  type: ButtonType;
};

export const Button = ({ onClick, children, type }: BackButtonProps) => {
  const className = `button--${type}`;
  return (
    <div
      className={styles[className]}
      onClick={() => {
        onClick();
      }}
    >
      {children}
    </div>
  );
};
