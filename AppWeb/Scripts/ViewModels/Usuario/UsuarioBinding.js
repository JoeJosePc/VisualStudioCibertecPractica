var formularioViewModel = new FormularioUsuario();
var formularioHTML = document.getElementById("FormularioTablaUsuario");
ko.applyBindings(formularioViewModel, formularioHTML);
formularioViewModel.TraerDatosDelServidor();