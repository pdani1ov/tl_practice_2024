import { useRef, useState } from "react";
import { LearningDeck, moveCurrentCardToDeckEnd, removeCurrentCard } from "../../model/types/LearningDeck";
import styles from "./LearningCards.module.scss";
import { LearningCard } from "./learningCard/LearningCard";
import { LearningCardsFinish } from "./learningCardsFinish/LearningCardsFinish";
import { LearningCardButtons } from "./learningCardsButtons/LearningCardsButtons";
import { LearningCardsHeader } from "./learningCardsHeader/LearningCardsHeader";
import { useAppStore } from "../../store/useAppStore";
import { useNavigate, useParams } from "react-router-dom";
import { randomCards } from "../../common/random";

export const LearningCards = () => {
  const navigate = useNavigate();
  const params = useParams();
  const deckId = params.id ?? "";
  const failsCountRef = useRef(0);
  const deck = useAppStore((state) => state.getDeckById(deckId));
  const [learningDeck, setLearningDeck] = useState<LearningDeck>({ ...deck, unlearnedCards: randomCards(deck.cards) });

  const unlearnedCards = [...learningDeck.unlearnedCards].reverse();

  const onSuccessClick = () => {
    setLearningDeck(removeCurrentCard(learningDeck));
  };

  const onFailClick = () => {
    failsCountRef.current++;
    setLearningDeck(moveCurrentCardToDeckEnd(learningDeck));
  };

  const onClose = () => {
    navigate(`/deck/${deck.id}`);
  };

  const onDeckList = () => {
    navigate(`/`);
  };

  return (
    <div className={styles["learning-cards-container"]}>
      <LearningCardsHeader onClose={onClose} name={learningDeck.name} />
      {unlearnedCards.length ? (
        <>
          <div className={styles["unlearning-cards"]}>
            {unlearnedCards.map((card) => (
              <LearningCard word={card.word} translation={card.translation} key={card.id} />
            ))}
          </div>
          <LearningCardButtons onFail={onFailClick} onSuccess={onSuccessClick} />
        </>
      ) : (
        <LearningCardsFinish onClick={onDeckList} failsCount={failsCountRef.current} />
      )}
    </div>
  );
};
