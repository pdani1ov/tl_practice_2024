import { StateCreator } from "zustand";
import { Application } from "../../model/types/Application";
import { Card } from "../../model/types/Card";
import {
  addNewCard,
  changeCardTranslation,
  changeCardWord,
  deleteCard,
  getCardById,
} from "../../model/methods/CardMethods";

export type CardSlice = {
  addNewCard: (deckId: string, word: string, translation: string) => void;
  removeCard: (deckId: string, cardId: string) => void;
  changeCardWord: (deckId: string, cardId: string, newWord: string) => void;
  changeCardTranslation: (deckId: string, cardId: string, newTranslation: string) => void;
  getCardById: (deckId: string, cardId: string) => Card;
};

export const createCardSlice: StateCreator<CardSlice & { info: Application }, [], [], CardSlice> = (set, get) => ({
  addNewCard: (deckId: string, word: string, translation: string) => {
    set((state) => ({
      info: addNewCard(state.info, deckId, word, translation),
    }));
  },
  removeCard: (deckId: string, cardId: string) => {
    set((state) => ({
      info: deleteCard(state.info, deckId, cardId),
    }));
  },
  changeCardWord: (deckId: string, cardId: string, newWord: string) => {
    set((state) => ({
      info: changeCardWord(state.info, deckId, cardId, newWord),
    }));
  },
  changeCardTranslation: (deckId: string, cardId: string, newTranslation: string) => {
    set((state) => ({
      info: changeCardTranslation(state.info, deckId, cardId, newTranslation),
    }));
  },
  getCardById: (deckId: string, cardId: string) => {
    return getCardById(get().info, deckId, cardId);
  },
});
