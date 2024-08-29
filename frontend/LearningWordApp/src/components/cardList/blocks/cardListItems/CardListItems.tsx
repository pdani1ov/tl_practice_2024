import { Deck } from "../../../../model/types/Deck";
import { CardListItem } from "../../item/CardListItem";
import styles from "./CardListItems.module.scss";

type CardListItemsProps = {
  deck: Deck;
};

export const CardListItems = ({ deck }: CardListItemsProps) => {
  return (
    <div className={styles["card-list-items-container"]}>
      <div className={styles["card-list-block-header"]}>{"Cards"}</div>
      <div className={styles["card-list-items"]}>
        {deck.cards.map((card) => (
          <CardListItem deckId={deck.id} cardId={card.id} key={card.id} />
        ))}
      </div>
    </div>
  );
};
