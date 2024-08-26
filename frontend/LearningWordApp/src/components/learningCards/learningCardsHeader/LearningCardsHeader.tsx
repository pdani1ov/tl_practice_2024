import { LeftArrowIcon } from "../../../icons/LeftArrowIcon";
import { Button } from "../../button/Button";
import styles from "./LearningCardsHeader.module.scss";

type LearningCardsHeaderProps = {
  name: string;
  onClose: () => void;
};

export const LearningCardsHeader = ({ name, onClose }: LearningCardsHeaderProps) => {
  return (
    <div className={styles["learning-cards-header"]}>
      <div className={styles["back-button-container"]}>
        <Button type="link" onClick={onClose}>
          <LeftArrowIcon width={50} height={50} />
        </Button>
      </div>
      <div className={styles["learning-cards-header-name"]}>{`Learning words - ${name}`}</div>
    </div>
  );
};
