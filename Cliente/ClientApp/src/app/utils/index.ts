import { Usuario } from "../tipos/usuario";

type ComentarioType = "BANDA" | "CANCION"; 

export const obtenerFiltros = (form: any, parametros: string[]) => {
    let filtros: any = null;
    parametros.forEach(param => {
      const paramValor = form.get(param)?.value;
      if(paramValor) {
        filtros = {
          ...filtros,
          [param]: paramValor
        }
      }
    });
    return filtros;
};

export const obtenerBody = (idUsuario: number, id: number, tipo: ComentarioType, form: any, parametros: string[]) => {
  const filtros = obtenerFiltros(form, parametros);
  return {
    ...filtros,
    IdUsuario: idUsuario,
    Id: id,
    Tipo: tipo
  };
};

export const setCalificacion = (form: any, parametros: string[], data: any) => {
  parametros.forEach(param => {
    form.get(param)?.setValue(data[param]);
  });
};

export const obtenerParametros = (filtros: any): string => {
   const parametros: string[] = [];
   filtros && Object.keys(filtros).forEach(key => {
      const valor = filtros[key];
      parametros.push(encodeURIComponent(key) + '=' + encodeURIComponent(valor));
   });
   return parametros.length > 0 ? '?' + parametros.join('&') : '';
}

export const obtenerFiltrosCalificacion = (idUsuario: number, id: number, tipo: ComentarioType) => ({
  Id: id,
  IdUsuario: idUsuario,
  Tipo: tipo
});

export const getLocalUsuario = (): Usuario => {
  const usuario = localStorage.getItem('session');
  return usuario && JSON.parse(usuario);
}; 

export const setLocalUsuario = (usuario: Usuario) => {
  localStorage.setItem('session', JSON.stringify(usuario));
}

export const removeLocalUsuario = () => {
  localStorage.removeItem('session');
}
