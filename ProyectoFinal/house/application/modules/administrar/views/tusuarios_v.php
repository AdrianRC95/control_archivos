    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Usuarios
        <small>.</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="#">Adminisitrar</a></li>
        <li class="active">Usuarios</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="row">
        <div class="col-xs-12">
          <div class="box">
            <!--div class="box-header">
              <h3 class="box-title">Hover Data Table</h3>
            </div-->
            <!-- /.box-header -->
            <div class="box-body pad table-responsive">
                
                <div class="alert alert-danger alert-dismissible <?php if(isset($data['mensaje'])){if($data['mensaje']!=0){echo 'hidden';}}?>">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <h4><i class="icon fa fa-close"></i> Error!</h4>
                    No se pudo eliminar el usuario, intente nuevamente.
                </div>
                <div class="alert alert-success alert-dismissible <?php if(isset($data['mensaje'])){if($data['mensaje']!=1){echo 'hidden';}}?>">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <h4><i class="icon fa fa-check"></i> Bien!</h4>
                    Usuario eliminado correctamente.
                </div>              
                
              <table id="example2" class="table table-bordered table-hover">
                <thead>
                <tr>
                  <th>id</th>
                  <th>Nombre</th>
                  <th>Email</th>
                  <th>Contraseña</th>
                <th>Rol</th>
                    <th></th>
                    <th>
                        <a href="<?php echo base_url(); ?>administrar/usuarios/agregar" class="btn btn-block btn-social btn-success">
                        <i class="fa fa-archive"></i>Agregar</a>
                    </th>
                </tr>
                </thead>
                <tbody>
                    
                    <?php if(isset($data['usuarios'])) { foreach ($data['usuarios'] as $usuario): ?>
                    <tr>
                        <td><?php echo $usuario['id_usuario']; ?></td>
                        <td><?php echo $usuario['nombre']; ?></td>
                        <td><?php echo $usuario['email']; ?></td>
                        <td><?php echo $usuario['password']; ?></td>
                        <td><?php echo $usuario['rol']; ?></td>
                        <td>
                            <a class="btn btn-block btn-primary btn-social" href="<?php echo base_url(); ?>administrar/usuarios/editar/<?php echo $usuario['id_usuario']; ?>" >
                            <i class="fa fa-edit"></i>Editar</a></td>
                        <td>
                            <a class="btn btn-block btn-danger btn-social" href="<?php echo base_url(); ?>administrar/usuarios/eliminar/<?php echo $usuario['id_usuario']; ?>">
                            <i class="fa fa-close"></i>Eliminar</a></td>
                    </tr>
                    <?php endforeach; }?>
                
                </tbody>
              </table>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->