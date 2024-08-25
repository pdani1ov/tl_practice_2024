import { useEffect, useState } from "react";
import styles from "./TextField.module.scss";

type TextFieldProps = {
  placeholder?: string;
  errorMessage: string;
  value?: string;
  onChange: (value: string) => void;
  valid?: boolean;
};

export const TextField = ({ placeholder, errorMessage, value, onChange, valid }: TextFieldProps) => {
  const [text, setText] = useState(value ?? "");

  useEffect(() => {
    if (value !== undefined) {
      setText(value);
    }
  }, [value]);

  const onChangeValue = (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;
    onChange(value);
    setText(value);
  };

  return (
    <div className={styles["text-field-container"]}>
      <div className={styles["text-field"]}>
        <input
          className={styles["text-field-input"]}
          placeholder={placeholder}
          type="text"
          value={text}
          onChange={onChangeValue}
        ></input>
      </div>
      <div className={styles["error-message"]} style={{ opacity: errorMessage && !valid ? 1 : 0 }}>
        {errorMessage}
      </div>
    </div>
  );
};
