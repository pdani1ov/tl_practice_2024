import { useState } from "react";
import { useAppStore } from "../../../../store/useAppStore";
import { TextField } from "../../../textField/TextField";
import { Button } from "../../../button/Button";
import styles from "./CreateCard.module.scss";
import { useCardFormValidation } from "../../../../hooks/useCardFormValidation";

type CreateCardProps = {
  deckId: string;
};

export const CreateCard = ({ deckId }: CreateCardProps) => {
  const addNewCardAction = useAppStore((state) => state.addNewCard);
  const [word, setWord] = useState("");
  const [translation, setTranslation] = useState("");
  const [isValidWord, isValidTranslation, checkValidation] = useCardFormValidation(word, translation);

  const onClick = () => {
    if (checkValidation()) {
      addNewCardAction(deckId, word, translation);
      setWord("");
      setTranslation("");
    }
  };

  return (
    <div className={styles["add-card-form"]}>
      <TextField placeholder="Word" errorMessage="Incorrect word" value={word} onChange={setWord} valid={isValidWord} />
      <TextField
        placeholder="Translation"
        errorMessage="Incorrect translation"
        value={translation}
        onChange={setTranslation}
        valid={isValidTranslation}
      />
      <Button type="default" onClick={onClick}>
        {"Add new card"}
      </Button>
    </div>
  );
};
