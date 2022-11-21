export interface Calificacion {
  Id: number;
  IdUsuario: number;
  Puntaje: number;
  Comentario: string;
  TipoCalificacion: "BANDA" | "CANCION"
}
