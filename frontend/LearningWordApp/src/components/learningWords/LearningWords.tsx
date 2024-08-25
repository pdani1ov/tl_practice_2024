import { useEffect, useRef, useState } from "react";
import { LearningDeck } from "../../model/types/LearningDeck";
import styles from "./LearningWords.module.scss";
import { Button } from "../button/Button";
import { LeftArrowIcon } from "../../icons/LeftArrowIcon";
import { LearningButton } from "../learningButton/LearningButton";
import { LearningCard } from "./leaningCard/LearningCard";
import finishImage from "../../images/finish.jpg";
import { Card } from "../../model/types/Card";

type LearningFinishProps = {
  onClick: () => void;
  failsCount: number;
};

const LearningFinish = ({ onClick, failsCount }: LearningFinishProps) => {
  return (
    <div className={styles["learning-finish-container"]}>
      <div className={styles["learning-finish"]}>
        <div className={styles["learning-finish-header"]}>{"Finish!"}</div>
        <img className={styles["finish-image"]} src={finishImage} alt="finish" />
        <div
          className={styles["learning-finish-number-mistakes"]}
        >{`Number of mistakes: ${failsCount.toString()}`}</div>
        <Button type="default" onClick={onClick}>
          {"Back to home screen"}
        </Button>
      </div>
    </div>
  );
};

type LearningButtonsProps = {
  onSuccess: () => void;
  onFail: () => void;
};

const LearningCardButtons = ({ onSuccess, onFail }: LearningButtonsProps) => {
  return (
    <div className={styles["learning-buttons-container"]}>
      <LearningButton onClick={onFail} type="negative">
        {"Fail"}
      </LearningButton>
      <LearningButton onClick={onSuccess} type="positive">
        {"Ok"}
      </LearningButton>
    </div>
  );
};

type LearningWordsProps = {
  learningDeck: LearningDeck;
  onClose: () => void;
  onDeckList: () => void;
  onSuccess: () => void;
  onFail: () => void;
};

export const LearningWords = ({ learningDeck, onClose, onDeckList, onSuccess, onFail }: LearningWordsProps) => {
  const failsCount = useRef(0);

  const [unlearnedCards, setUnlearnedCards] = useState<Card[]>([]);

  useEffect(() => {
    setUnlearnedCards([...learningDeck.unlearnedCards].reverse());
  }, [learningDeck]);

  const onSuccessClick = () => {
    onSuccess();
  };

  const onFailClick = () => {
    failsCount.current++;
    onFail();
  };

  return (
    <div className={styles["learning-words-container"]}>
      <div className={styles["learning-words-header"]}>
        <div className={styles["back-button-container"]}>
          <Button type="link" onClick={onClose}>
            <LeftArrowIcon width={50} height={50} />
          </Button>
        </div>
        <div className={styles["learning-words-header-name"]}>{`Learning words - ${learningDeck.name}`}</div>
      </div>
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
        <LearningFinish onClick={onDeckList} failsCount={failsCount.current} />
      )}
    </div>
  );
};
