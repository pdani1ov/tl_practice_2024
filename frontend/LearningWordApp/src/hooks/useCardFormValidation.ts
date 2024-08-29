import { useState } from "react";

export const useCardFormValidation = (word: string, translation: string): [boolean, boolean, () => boolean] => {
  const [isValidWord, setIsValidWord] = useState(true);
  const [isValidTranslation, setIsValidTranslation] = useState(true);

  const checkWordAndTranslation = (): boolean => {
    const wordIsValid = word.trim().length !== 0;
    const translationIsValid = translation.trim().length !== 0;

    setIsValidWord(wordIsValid);
    setIsValidTranslation(translationIsValid);

    return wordIsValid && translationIsValid;
  };

  return [isValidWord, isValidTranslation, checkWordAndTranslation];
};
