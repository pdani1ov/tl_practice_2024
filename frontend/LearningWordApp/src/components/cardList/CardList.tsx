import { useEffect, useState } from "react";
import { Button } from "../button/Button";
import { TextField } from "../textField/TextField";
import styles from "./CardList.module.scss";
import { useAppStore } from "../../store/useAppStore";
import { Deck } from "../../model/types/Deck";
import { CardListItem } from "./item/CardListItem";
import { LeftArrowIcon } from "../../icons/LeftArrowIcon";
import { PlayIcon } from "../../icons/PlayIcon";

type ChangeDeckNameBlockProps = {
  deckId: string;
};

const ChangeDeckNameBlock = ({ deckId }: ChangeDeckNameBlockProps) => {
  const changeDeckName = useAppStore((state) => state.actions.changeDeckName);

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
    <div className={styles["card-list-change-name-block"]}>
      <div className={styles["block-header"]}>{"Change name"}</div>
      <div className={styles["card-list-change-name"]}>
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

type CardListBlockProps = {
  deck: Deck;
};

const CardListBlock = ({ deck }: CardListBlockProps) => {
  return (
    <div className={styles["card-list-items-block"]}>
      <div className={styles["block-header"]}>{"Cards"}</div>
      <div className={styles["card-list-items"]}>
        {deck.cards.map((card) => (
          <CardListItem deckId={deck.id} cardId={card.id} key={card.id} />
        ))}
      </div>
    </div>
  );
};

type CreateCardFormProps = {
  deckId: string;
};

const CreateCardForm = ({ deckId }: CreateCardFormProps) => {
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

type CardListProps = {
  onClose: () => void;
  learnWords: () => void;
  deckId: string;
};

export const CardList = ({ onClose, learnWords, deckId }: CardListProps) => {
  const deck = useAppStore((state) => state.actions.getDeckById(deckId));

  const [deckName, setDeckName] = useState("");
  const [isVisibleErrorMsg, setIsVisibleErrorMsg] = useState(false);

  const onClickLearnButton = () => {
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
        <div className={styles["card-list-header"]}>
          <Button type="link" onClick={onClose}>
            <LeftArrowIcon width={50} height={50} />
          </Button>
          <div className={styles["card-list-header-name"]}>{deckName}</div>
          <Button type="link" onClick={onClickLearnButton}>
            {"learn"}
            <PlayIcon width={30} height={30} />
          </Button>
        </div>
        <ChangeDeckNameBlock deckId={deck.id} />
        <CardListBlock deck={deck} />
        <CreateCardForm deckId={deck.id} />
      </div>
      <div className={styles["error-msg"]} style={{ opacity: isVisibleErrorMsg ? 1 : 0 }}>
        {"There are no study cards in this deck! Add new cards!"}
      </div>
    </>
  );
};
