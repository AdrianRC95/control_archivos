<!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Usuarios
        <small>.</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="#">Administrar</a></li>
        <li class="active">Editar Usuario</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="row center-block">
        <div class="col-md-6">
                <!-- Input addon -->
            <div class="box box-info">
            <div class="box-header with-border">
              <h3 class="box-title">Editar Usuario</h3>
            </div>
            <!-- form start -->
            <form role="form" method="post" action="<?php echo base_url(); ?>administrar/usuarios/updateUsuario">         
            <div class="box-body">
                
            <div class="alert alert-danger alert-dismissible <?php if(isset($data['mensaje'])){if($data['mensaje']!=0){echo 'hidden';}}?>">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <h4><i class="icon fa fa-close"></i> Error!</h4>
                Datos no actualizados, intente nuevamente.
            </div>
            
            <div class="alert alert-success alert-dismissible <?php if(isset($data['mensaje'])){if($data['mensaje']!=1){echo 'hidden';}}?>">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <h4><i class="icon fa fa-check"></i> Bien!</h4>
                Usuario actualizado correctamente.
            </div>
                
            <div class="alert alert-danger alert-dismissible <?php if(isset($data['usuario'])){if($data['usuario']!=null){echo 'hidden';}}?>">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <h4><i class="icon fa fa-close"></i> Error!</h4>
                No se encontró información del usuario.
            </div>
            <?php if(!empty($data['usuario'])){ $usuario = $data['usuario'][0];?>
              <div class="input-group hidden">
                <span class="input-group-addon"><i class="fa fa-user"></i></span>
                <input name="id" type="text" value="<?php echo $usuario['id_usuario']; ?>" 
                       class="form-control" placeholder="Id" required>
              </div>
              <br>
              <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-user"></i></span>
                <input name="nombre" type="text" value="<?php echo $usuario['nombre']; ?>"
                       class="form-control" placeholder="Nombre" required>
              </div>
              <br>
              <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                <input name="email" type="email" value="<?php echo $usuario['email']; ?>"
                       class="form-control" placeholder="Email" required>
              </div>
              <br>
              <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-key"></i></span>
                <input name="pass" type="password" value="<?php echo $usuario['password']; ?>" 
                       class="form-control" placeholder="Password" required>
              </div>
              <br>
              <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-gears"></i></span>
                <select name="rol" class="form-control" required>
                    <option value="Admin" <?php echo ($usuario['rol']=='Admin')?'selected':''; ?> >Admin</option>
                    <option value="Usuario" <?php echo ($usuario['rol']=='Usuario')?'selected':''; ?> >Usuario</option>
                    <option value="Invitado" <?php echo ($usuario['rol']=='Invitado')?'selected':''; ?> >Invitado</option>
                  </select>
              </div>
              <br>
              <button type="submit" class="btn btn-primary center-block">Actualizar</button>
              <!-- /input-group -->
            <?php } ?>    
            </div>
            <!-- /.box-body -->
            <div class="box-footer">
                <h4>
                    <a href="<?php echo base_url(); ?>administrar/usuarios"><i class="fa fa-angle-double-left"></i> regresar</a>
                </h4>
            </div>
            </form>                
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->