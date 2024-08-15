import { v4 as uuidv4 } from "uuid";

export type Card = {
    id: string;
    word: string;
    translation: string;
};

function createCard(word: string, translation: string): Card {
    return {
        id: uuidv4(),
        word,
        translation
    };
}

function changeWordInCard(card: Card, word: string): Card {
    return {
        ...card,
        word
    };
}

function changeTranslationInCard(card: Card, translation: string): Card {
    return {
        ...card,
        translation
    };
}

export {
    createCard,
    changeWordInCard,
    changeTranslationInCard
}