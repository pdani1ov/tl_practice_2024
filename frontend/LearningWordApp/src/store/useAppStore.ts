import { create } from "zustand";
import { Application } from "../model/types/Application";
import { createJSONStorage, persist } from "zustand/middleware";
import { createDeckSlice, DeckSlice } from "./slices/DeckSlice";
import { CardSlice, createCardSlice } from "./slices/CardSlice";

type AppStoreData = DeckSlice &
  CardSlice & {
    info: Application;
  };

export const useAppStore = create<AppStoreData>()(
  persist(
    (...a) => ({
      info: {
        decks: [],
      },
      ...createDeckSlice(...a),
      ...createCardSlice(...a),
    }),
    {
      name: "word-learning-app-tl",
      storage: createJSONStorage(() => localStorage),
      partialize: (state) => ({ info: state.info }),
    },
  ),
);
