import { useState } from "react";
import { useAppStore } from "../../../store/useAppStore";
import styles from "./CardListItem.module.scss";
import { Button } from "../../button/Button";
import { DeleteIcon } from "../../../icons/DeleteIcon";

type CardListItemProps = {
  deckId: string;
  cardId: string;
};

export const CardListItem = ({ deckId, cardId }: CardListItemProps) => {
  const card = useAppStore((state) => state.getCardById(deckId, cardId));
  const [word, setWord] = useState(card.word);
  const [translation, setTranslation] = useState(card.translation);
  const { changeCardWord, changeCardTranslation, removeCard } = useAppStore((state) => state);

  const changeWord = (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;
    changeCardWord(deckId, cardId, value);
    setWord(value);
  };

  const changeTranslation = (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;
    changeCardTranslation(deckId, cardId, value);
    setTranslation(value);
  };

  const onClickRemoveButton = () => {
    removeCard(deckId, cardId);
  };

  return (
    <div className={styles["item-container"]}>
      <input className={styles["item-input"]} placeholder="word" onChange={changeWord} value={word} />
      <div className={styles["item-separator"]} />
      <input
        className={styles["item-input"]}
        placeholder="translation"
        onChange={changeTranslation}
        value={translation}
      />
      <div className={styles["item-separator"]} />
      <Button onClick={onClickRemoveButton} type="delete">
        <DeleteIcon width={30} height={30} />
      </Button>
    </div>
  );
};
