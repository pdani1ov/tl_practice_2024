import "./App.css";
import { DeckList } from "./components/deckList/DeckList";
import { CardList } from "./components/cardList/CardList";
import { LearningCards } from "./components/learningCards/LearningCards";
import { BrowserRouter, Route, Routes } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<DeckList />} />
        <Route path="/deck">
          <Route path=":id" element={<CardList />} />
        </Route>
        <Route path="/learning">
          <Route path=":id" element={<LearningCards />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
