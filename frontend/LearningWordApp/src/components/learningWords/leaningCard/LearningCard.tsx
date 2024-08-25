import { useRef, useState } from "react";
import styles from "./LearningCard.module.scss";
import { getRandomNumber } from "../../../common/random";

type LearningCardProps = {
  word: string;
  translation: string;
};

type CardSide = "front" | "back";

export const LearningCard = ({ word, translation }: LearningCardProps) => {
  const cardRotate = useRef(getRandomNumber(-10, 10));
  const [cardSide, setCardSide] = useState<CardSide>("front");
  const className = `card-container-${cardSide}`;

  const onClick = () => {
    if (cardSide === "front") {
      setCardSide("back");
    } else {
      setCardSide("front");
    }
  };

  return (
    <div
      className={styles[className]}
      style={{ transform: `rotate(${cardRotate.current.toString()}deg)` }}
      onClick={() => {
        onClick();
      }}
    >
      <div style={{ transform: `rotate(${(-cardRotate.current).toString()}deg)` }}>
        {cardSide === "front" ? word : translation}
      </div>
    </div>
  );
};
