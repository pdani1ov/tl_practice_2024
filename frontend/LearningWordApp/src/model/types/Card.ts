import { v4 as uuidv4 } from "uuid";

export type Card = {
    id: string;
    word: string;
    translation: string;
};

function createCard(word: string, translation: string): Card {
    return {
        id: uuidv4(),
        word: word,
        translation: translation
    };
}

function changeWordInCard(card: Card, word: string): Card {
    return {
        ...card,
        word: word
    };
}

function changeTranslationInCard(card: Card, translation: string): Card {
    return {
        ...card,
        translation: translation
    };
}

export {
    createCard,
    changeWordInCard,
    changeTranslationInCard
}