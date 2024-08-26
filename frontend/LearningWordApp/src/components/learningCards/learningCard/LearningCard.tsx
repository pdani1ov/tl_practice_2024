import { useRef, useState } from "react";
import styles from "./LearningCard.module.scss";
import { getRandomNumber } from "../../../common/random";

type LearningCardProps = {
  word: string;
  translation: string;
};

export const LearningCard = ({ word, translation }: LearningCardProps) => {
  const cardRotateRef = useRef(getRandomNumber(-10, 10));
  const [isCardFrontSideVisible, setIsCardFrontSideVisible] = useState(true);
  const className = isCardFrontSideVisible ? "card-container-front" : "card-container-back";

  const onClick = () => {
    if (isCardFrontSideVisible) {
      setIsCardFrontSideVisible(false);
    } else {
      setIsCardFrontSideVisible(true);
    }
  };

  return (
    <div
      className={styles[className]}
      style={{ transform: `rotate(${cardRotateRef.current.toString()}deg)` }}
      onClick={() => {
        onClick();
      }}
    >
      <div style={{ transform: `rotate(${(-cardRotateRef.current).toString()}deg)` }}>
        {isCardFrontSideVisible ? word : translation}
      </div>
    </div>
  );
};
