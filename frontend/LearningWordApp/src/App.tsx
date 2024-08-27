import { useEffect, useState } from "react";
import "./App.css";
import { DeckList } from "./components/deckList/DeckList";
import { Deck } from "./model/types/Deck";
import { CardList } from "./components/cardList/CardList";
import { useAppStore } from "./store/useAppStore";
import { LearningCards } from "./components/learningCards/LearningCards";
import { LearningDeck, moveCurrentCardToDeckEnd, removeCurrentCard } from "./model/types/LearningDeck";
import { randomCards } from "./common/random";

type LearningWordsAppState = "decks" | "cards" | "learning";

function App() {
  const getDeckById = useAppStore((state) => state.getDeckById);

  const [selectedDeckId, setSelectedDeckId] = useState<string | undefined>();
  const [appState, setAppState] = useState<LearningWordsAppState>("decks");
  const [learningDeck, setLearningDeck] = useState<LearningDeck | undefined>(undefined);

  const openCardList = (deck: Deck) => {
    setSelectedDeckId(deck.id);
    setLearningDeck(undefined);
    setAppState("cards");
  };

  const openLearningDeck = () => {
    if (selectedDeckId !== undefined) {
      const deck = getDeckById(selectedDeckId);
      setLearningDeck({ ...deck, unlearnedCards: randomCards(deck.cards) });
      setAppState("learning");
    }
  };

  const onLearnSuccess = () => {
    if (learningDeck !== undefined) {
      setLearningDeck(removeCurrentCard(learningDeck));
    }
  };

  const onLearnFail = () => {
    if (learningDeck !== undefined) {
      setLearningDeck(moveCurrentCardToDeckEnd(learningDeck));
    }
  };

  useEffect(() => {
    if (appState === "decks") {
      setSelectedDeckId(undefined);
    }
  }, [appState]);

  if (selectedDeckId !== undefined && appState === "cards") {
    return (
      <CardList
        onClose={() => {
          setAppState("decks");
        }}
        learnWords={openLearningDeck}
        deckId={selectedDeckId}
      />
    );
  } else if (selectedDeckId !== undefined && learningDeck !== undefined && appState === "learning") {
    return (
      <LearningCards
        learningDeck={learningDeck}
        onClose={() => {
          setAppState("cards");
        }}
        onDeckList={() => {
          setAppState("decks");
        }}
        onSuccess={onLearnSuccess}
        onFail={onLearnFail}
      />
    );
  } else {
    return <DeckList selectDeck={openCardList} />;
  }
}

export default App;
