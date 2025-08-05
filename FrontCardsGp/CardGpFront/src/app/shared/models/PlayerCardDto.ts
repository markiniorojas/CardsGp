export interface PlayerCardDto {
  isUsed: boolean;
  userName: number;
  cardName: string;
  cylinderCapacity: number;
  hP: number;
  finalSpeed: number;
  nOclylinder: number;
  weight: number; // Cambiado de string a number si backend lo permite
  torque: number;
  image?: string;
  detailedImage?: string;
}
