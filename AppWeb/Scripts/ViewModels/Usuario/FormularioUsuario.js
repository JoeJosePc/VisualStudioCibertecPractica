function FormularioUsuario() {
    var self = this;
    self.Usuario = ko.observable("");
    self.Password = ko.observable("");
    self.Responsable = ko.observable("");
    self.Nivel = ko.observable("");
    self.Modal = $('#myModal');
    self.Usuarios = ko.observableArray([]);
    self.TablaDeUsuarios = $('#TablaDeUsuarios').DataTable();

    self.LimpiarFormulario = function () {
        self.Usuario("");
        self.Password("");
        self.Responsable("");
        self.Nivel("");
        self.Modal.modal('hide');
    }

    self.TraerDatosDelServidor = function () {
        self.Usuarios([]);
        $.get("../api/usuarios", function (usuarios) {
            self.Usuarios(usuarios);
        });
    }

    self.AgregarUsuarioATabla = function (usuario) {
        self.TablaDeUsuarios.row.add(
                    [
                        usuario.Usuario,
                        usuario.Responsable,
                        usuario.Nivel,
                        usuario.Estado
                    ]
        );
    }

    self.Usuarios.subscribe(function () {
        self.TablaDeUsuarios.clear();
        self.Usuarios().forEach(function (usuario) {
            self.AgregarUsuarioATabla(usuario);
        })
        self.TablaDeUsuarios.draw()
    })

    self.RegistrarUsuario = function () {
        var dataDelUsuario = self.SacarDataDelFormulario();
        Post(
                "../api/usuarios",
                dataDelUsuario,
                function (usuario) {
                    self.Usuarios.push(usuario);
                    self.LimpiarFormulario();
                    $.notify(usuario.Usuario + " Se grabo de manera correcta", "success");
                }
        );
    }

    self.SacarDataDelFormulario = function () {
        return {
            Usuario: self.Usuario(),
            Contrasena: self.Password(),
            Responsable: self.Responsable(),
            Nivel: self.Nivel()
        }
    }


    return self;
}
