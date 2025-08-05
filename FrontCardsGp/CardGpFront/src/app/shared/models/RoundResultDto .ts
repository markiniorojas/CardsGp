import { GamePlayerDto } from "./GamePlayerDto ";

export interface RoundResultDto {
  winner: GamePlayerDto | null;
  nextPlayer: GamePlayerDto | null;
  message: string;
}