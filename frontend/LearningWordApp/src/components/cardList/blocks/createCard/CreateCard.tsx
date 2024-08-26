import { useState } from "react";
import { useAppStore } from "../../../../store/useAppStore";
import { TextField } from "../../../textField/TextField";
import { Button } from "../../../button/Button";
import styles from "./CreateCard.module.scss";

type CreateCardProps = {
  deckId: string;
};

export const CreateCard = ({ deckId }: CreateCardProps) => {
  const addNewCardAction = useAppStore((state) => state.actions.addNewCard);
  const [word, setWord] = useState("");
  const [translation, setTranslation] = useState("");
  const [isValidWord, setIsValidWord] = useState(true);
  const [isValidTranslation, setIsValidTranslation] = useState(true);

  const onClick = () => {
    if (word.length !== 0 && translation.length !== 0) {
      setIsValidWord(true);
      setIsValidTranslation(true);
      addNewCardAction(deckId, word, translation);
      setWord("");
      setTranslation("");
      return;
    }
    setIsValidWord(word.length !== 0);
    setIsValidTranslation(translation.length !== 0);
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
