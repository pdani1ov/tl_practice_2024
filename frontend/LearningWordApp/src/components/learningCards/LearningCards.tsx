import { useRef } from "react";
import { LearningDeck } from "../../model/types/LearningDeck";
import styles from "./LearningCards.module.scss";
import { LearningCard } from "./learningCard/LearningCard";
import { LearningCardsFinish } from "./learningCardsFinish/LearningCardsFinish";
import { LearningCardButtons } from "./learningCardsButtons/LearningCardsButtons";
import { LearningCardsHeader } from "./learningCardsHeader/LearningCardsHeader";

type LearningCardsProps = {
  learningDeck: LearningDeck;
  onClose: () => void;
  onDeckList: () => void;
  onSuccess: () => void;
  onFail: () => void;
};

export const LearningCards = ({ learningDeck, onClose, onDeckList, onSuccess, onFail }: LearningCardsProps) => {
  const failsCountRef = useRef(0);

  const unlearnedCards = [...learningDeck.unlearnedCards].reverse();

  const onSuccessClick = () => {
    onSuccess();
  };

  const onFailClick = () => {
    failsCountRef.current++;
    onFail();
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
