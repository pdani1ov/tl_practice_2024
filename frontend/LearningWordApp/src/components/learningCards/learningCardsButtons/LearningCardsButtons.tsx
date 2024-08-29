import { LearningButton } from "../../learningButton/LearningButton";
import styles from "./LearningCardsButtons.module.scss";

type LearningButtonsProps = {
  onSuccess: () => void;
  onFail: () => void;
};

export const LearningCardButtons = ({ onSuccess, onFail }: LearningButtonsProps) => {
  return (
    <div className={styles["learning-cards-buttons-container"]}>
      <LearningButton onClick={onFail} type="negative">
        {"Fail"}
      </LearningButton>
      <LearningButton onClick={onSuccess} type="positive">
        {"Ok"}
      </LearningButton>
    </div>
  );
};
