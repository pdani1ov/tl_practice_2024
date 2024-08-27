import { useState } from "react";
import { useAppStore } from "../../../../store/useAppStore";
import { TextField } from "../../../textField/TextField";
import { Button } from "../../../button/Button";
import styles from "./ChangeDeckName.module.scss";

type ChangeDeckNameProps = {
  deckId: string;
};

export const ChangeDeckName = ({ deckId }: ChangeDeckNameProps) => {
  const changeDeckName = useAppStore((state) => state.changeDeckName);

  const [newDeckName, setNewDeckName] = useState("");
  const [isValidDeckName, setIsValidDeckName] = useState(true);

  const changeName = () => {
    if (newDeckName.trim().length === 0) {
      setIsValidDeckName(false);
      return;
    }

    setIsValidDeckName(true);
    changeDeckName(deckId, newDeckName);
    setNewDeckName("");
  };

  return (
    <div className={styles["change-name-block"]}>
      <div className={styles["change-name-block-header"]}>{"Change name"}</div>
      <div className={styles["change-name"]}>
        <TextField
          placeholder="Name of new deck"
          errorMessage="Incorrect name"
          value={newDeckName}
          onChange={setNewDeckName}
          valid={isValidDeckName}
        />
        <Button type="default" onClick={changeName}>
          {"Change deck name"}
        </Button>
      </div>
    </div>
  );
};
