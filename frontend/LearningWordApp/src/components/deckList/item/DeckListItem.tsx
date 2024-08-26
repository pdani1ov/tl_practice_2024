import { Deck } from "../../../model/types/Deck";
import styles from "./DeckListItem.module.scss";
import { Button } from "../../button/Button";
import { DeleteIcon } from "../../../icons/DeleteIcon";

type DeckListItemProps = {
  deck: Deck;
  onClick: () => void;
  onDeleteClick: (deckId: string) => void;
};

export const DeckListItem = ({ deck, onClick, onDeleteClick }: DeckListItemProps) => {


  return (
    <>
      <div
        className={styles["deck-item"]}
        onClick={() => {
          onClick();
        }}
      >
        <div className={styles["item-info"]}>
          <div className={styles["item-name"]}>{deck.name}</div>
          <div className={styles["item-cards-count"]}>{`Количество карточек: ${deck.cards.length.toString()}`}</div>
        </div>
        <Button
          type="delete"
          onClick={() => {
            onDeleteClick(deck.id);
          }}
        >
          <DeleteIcon width={30} height={30} />
        </Button>
      </div>
    </>
  );
};
