import { Button } from "../../button/Button";
import styles from "./LearningCardsFinish.module.scss";
import finishImage from "../../../images/finish.jpg";

type LearningCardsFinishProps = {
  onClick: () => void;
  failsCount: number;
};

export const LearningCardsFinish = ({ onClick, failsCount }: LearningCardsFinishProps) => {
  return (
    <div className={styles["learning-cards-finish-container"]}>
      <div className={styles["learning-cards-finish"]}>
        <div className={styles["learning-cards-finish-header"]}>{"Finish!"}</div>
        <img draggable={false} className={styles["finish-image"]} src={finishImage} alt="finish" />
        <div
          className={styles["learning-cards-finish-number-mistakes"]}
        >{`Number of mistakes: ${failsCount.toString()}`}</div>
        <Button type="default" onClick={onClick}>
          {"Back to home screen"}
        </Button>
      </div>
    </div>
  );
};
