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
                    No se pudo eliminar, intente nuevamente.
                </div>
                <div class="alert alert-success alert-dismissible <?php if(isset($data['mensaje'])){if($data['mensaje']!=1){echo 'hidden';}}?>">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <h4><i class="icon fa fa-check"></i> Bien!</h4>
                    Asociación eliminada correctamente.
                </div>  
                
              <table id="example2" class="table table-bordered table-hover">
                <thead>
                <tr>
                  <th>id</th>
                  <th>usuario</th>
                  <th>dispositivo</th>
                    <th>
                        <a class="btn btn-block btn-social btn-success" href="<?php echo base_url();?>administrar/asociacion/agregar">
                        <i class="fa fa-archive"></i>Agregar</a>
                    </th>
                </tr>
                </thead>
                <tbody>
                    
                    <?php if(isset($data['asociacion'])) { foreach ($data['asociacion'] as $asociacion): ?>
                    <tr>
                        <td><?php echo $asociacion['registro']; ?></td>
                        <td><?php echo $asociacion['usuario']; ?></td>
                        <td><?php echo $asociacion['dispositivo']; ?></td>
                        <td><a class="btn btn-block btn-danger btn-social" href="<?php echo base_url(); ?>administrar/asociacion/eliminar/<?php echo $asociacion['registro']; ?>">
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