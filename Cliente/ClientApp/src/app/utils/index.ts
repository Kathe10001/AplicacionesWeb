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


export const obtenerParametros = (filtros: any): string => {
   const parametros: string[] = [];
   filtros && Object.keys(filtros).forEach(key => {
      const valor = filtros[key];
      parametros.push(encodeURIComponent(key) + '=' + encodeURIComponent(valor));
   });
   return parametros.length > 0 ? '?' + parametros.join('&') : '';
}
