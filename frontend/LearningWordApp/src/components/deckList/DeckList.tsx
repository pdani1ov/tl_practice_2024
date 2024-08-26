import { Deck } from "../../model/types/Deck";
import { useAppStore } from "../../store/useAppStore";
import { DeckListItem } from "./item/DeckListItem";
import styles from "./DeckList.module.scss";
import { TextField } from "../textField/TextField";
import { useState } from "react";
import { Button } from "../button/Button";

type DeckListProps = {
  selectDeck: (deck: Deck) => void;
};

export const DeckList = ({ selectDeck }: DeckListProps) => {
  const decks: Deck[] = useAppStore((state) => state.info.decks);
  const { addNewDeck, removeDeck } = useAppStore((state) => state.actions);

  const [newDeckName, setNewDeckName] = useState("");
  const [isValidDeckName, setIsValidDeckName] = useState(true);

  const createDeck = () => {
    if (newDeckName.length === 0) {
      setIsValidDeckName(false);
      return;
    }
    setIsValidDeckName(true);
    addNewDeck(newDeckName);
    setNewDeckName("");
  };

  const onDeleteClick = (deckId: string) => {
    removeDeck(deckId);
  };

  return (
    <div className={styles["deck-list"]}>
      <div className={styles["deck-list-header"]}>{"Deck list"}</div>
      <div className={styles["deck-list-items"]}>
        {decks.map((deck) => (
          <DeckListItem
            key={deck.id}
            deck={deck}
            onClick={() => {
              selectDeck(deck);
            }}
            onDeleteClick={onDeleteClick}
          />
        ))}
      </div>
      <div className={styles["deck-creator"]}>
        <TextField
          placeholder="Name of new deck"
          errorMessage="Incorrect name"
          value={newDeckName}
          onChange={setNewDeckName}
          valid={isValidDeckName}
        />
        <Button type="default" onClick={createDeck}>
          {"Add deck"}
        </Button>
      </div>
    </div>
  );
};
