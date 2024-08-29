import { LeftArrowIcon } from "../../../../icons/LeftArrowIcon";
import { PlayIcon } from "../../../../icons/PlayIcon";
import { Button } from "../../../button/Button";
import styles from "./CardListHeader.module.scss";

type CardListHeaderProps = {
  name: string;
  onClose: () => void;
  onLearn: () => void;
};

export const CardListHeader = ({ name, onClose, onLearn }: CardListHeaderProps) => {
  return (
    <div className={styles["card-list-header"]}>
      <Button type="link" onClick={onClose}>
        <LeftArrowIcon width={50} height={50} />
      </Button>
      <div className={styles["card-list-header-name"]}>{name}</div>
      <Button type="link" onClick={onLearn}>
        {"learn"}
        <PlayIcon width={30} height={30} />
      </Button>
    </div>
  );
};
