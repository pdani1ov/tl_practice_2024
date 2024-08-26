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

  const onButtonClick = (event: React.MouseEvent<HTMLDivElement>) => {
    event.stopPropagation();
    onClick();
  };

  return (
    <div className={styles[className]} onClick={onButtonClick}>
      {children}
    </div>
  );
};
