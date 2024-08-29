import styles from "./ErrorMessage.module.scss";

type ErrorMessageProps = {
  isVisibleErrorMsg: boolean;
  message: string;
};

export const ErrorMessage = ({ isVisibleErrorMsg, message }: ErrorMessageProps) => {
  return (
    <div className={styles["error-msg"]} style={{ opacity: isVisibleErrorMsg ? 1 : 0 }}>
      {message}
    </div>
  );
};
