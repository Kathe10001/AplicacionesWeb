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

export const getCookie = (n: string, from: string): string => {
    const name = n + '=';
    const cDecoded = decodeURIComponent(from);
    const cArr = cDecoded.split('; ');
    let res: string = '';
    cArr.forEach(val => {
        if (val.indexOf(name) === 0) res = val.substring(name.length);
    });
    return res;
};

export const setCookie = (cName: string, cValue: string, expDays = 1) => {
    let date = new Date();
    date.setTime(date.getTime() + (expDays * 24 * 60 * 60 * 1000));
    const expires = "expires=" + date.toUTCString();
    document.cookie = cName + "=" + cValue + "; " + expires + "; path=/";
}
