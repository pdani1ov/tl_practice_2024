import { useEffect, useState } from "react";
import styles from "./CardList.module.scss";
import { useAppStore } from "../../store/useAppStore";
import { ChangeDeckName } from "./blocks/changeDeckName/ChangeDeckName";
import { CardListItems } from "./blocks/cardListItems/CardListItems";
import { CreateCard } from "./blocks/createCard/CreateCard";
import { CardListHeader } from "./blocks/cardListHeader/CardListHeader";
import { ErrorMessage } from "../errorMessage/ErrorMessage";
import { useNavigate, useParams } from "react-router-dom";

export const CardList = () => {
  const navigate = useNavigate();
  const params = useParams();
  const deckId = params.id ?? "";
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
    navigate(`/learning/${deck.id}`);
  };

  const onClose = () => {
    navigate(`/`);
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
