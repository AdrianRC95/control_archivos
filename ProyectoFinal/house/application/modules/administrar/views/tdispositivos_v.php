<!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Dispositivos
        <small>.</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="#">Administrar</a></li>
        <li class="active">Dispositivos</li>
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
                    No se pudo eliminar el dispositivo, intente nuevamente.
                </div>
                <div class="alert alert-success alert-dismissible <?php if(isset($data['mensaje'])){if($data['mensaje']!=1){echo 'hidden';}}?>">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <h4><i class="icon fa fa-check"></i> Bien!</h4>
                    Dispositivo eliminado correctamente.
                </div>  
                
              <table id="example2" class="table table-bordered table-hover">
                <thead>
                <tr>
                  <th>id</th>
                  <th>Nombre</th>
                  <th>Localización</th>
                  <th>Tipo</th>
                  <th>Estado</th>
                <th>Valor</th>
                    <th></th>
                    <th>
                        <a href="<?php echo base_url(); ?>administrar/dispositivos/agregar" class="btn btn-block btn-social btn-success">
                        <i class="fa fa-archive"></i>Agregar</a>
                    </th>
                </tr>
                </thead>
                <tbody>
                    
                    <?php if(isset($data['dispositivos'])) { foreach ($data['dispositivos'] as $dispositivo): ?>
                    <tr>
                        <td><?php echo $dispositivo['id_dispositivo']; ?></td>
                        <td><?php echo $dispositivo['nombre']; ?></td>
                        <td><?php echo $dispositivo['localizacion']; ?></td>
                        <td><?php echo $dispositivo['tipo']; ?></td>
                        <td><?php echo $dispositivo['estado']; ?></td>
                        <td><?php echo $dispositivo['valor']; ?></td>
                        <td>
                            <a class="btn btn-block btn-primary btn-social" href="<?php echo base_url(); ?>administrar/dispositivos/editar/<?php echo $dispositivo['id_dispositivo']; ?>" >
                            <i class="fa fa-edit"></i>Editar</a></td>
                        <td>
                            <a class="btn btn-block btn-danger btn-social" href="<?php echo base_url(); ?>administrar/dispositivos/eliminar/<?php echo $dispositivo['id_dispositivo']; ?>">
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