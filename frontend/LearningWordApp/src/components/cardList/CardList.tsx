import { useEffect, useState } from "react";
import styles from "./CardList.module.scss";
import { useAppStore } from "../../store/useAppStore";
import { ChangeDeckName } from "./blocks/changeDeckName/ChangeDeckName";
import { CardListItems } from "./blocks/cardListItems/CardListItems";
import { CreateCard } from "./blocks/createCard/CreateCard";
import { CardListHeader } from "./blocks/cardListHeader/CardListHeader";
import { ErrorMessage } from "../errorMessage/ErrorMessage";

type CardListProps = {
  onClose: () => void;
  learnWords: () => void;
  deckId: string;
};

export const CardList = ({ onClose, learnWords, deckId }: CardListProps) => {
  const deck = useAppStore((state) => state.getDeckById(deckId));

  const [deckName, setDeckName] = useState("");
  const [isVisibleErrorMsg, setIsVisibleErrorMsg] = useState(false);

  const onLearn = () => {
    if (deck.cards.length === 0) {
      setIsVisibleErrorMsg(true);
      setTimeout(() => {
        setIsVisibleErrorMsg(false);
      }, 2000);
      return;
    }
    learnWords();
  };

  useEffect(() => {
    setDeckName(deck.name);
  }, [deck]);

  return (
    <>
      <div className={styles["card-list"]}>
        <CardListHeader name={deckName} onClose={onClose} onLearn={onLearn} />
        <ChangeDeckName deckId={deck.id} />
        <CardListItems deck={deck} />
        <CreateCard deckId={deck.id} />
      </div>
      <ErrorMessage
        isVisibleErrorMsg={isVisibleErrorMsg}
        message="There are no study cards in this deck! Add new cards!"
      />
    </>
  );
};
