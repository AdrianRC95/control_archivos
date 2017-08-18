<!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Dispositivos
        <small>.</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="#">Administrar</a></li>
        <li class="active">Agregar Dispositivo</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="row center-block">
        <div class="col-md-6">
                <!-- Input addon -->
            <div class="box box-info">
            <div class="box-header with-border">
              <h3 class="box-title">Agregar Dispositivo</h3>
            </div>
            <!-- form start -->
            <form role="form" method="post" action="<?php echo base_url(); ?>administrar/dispositivos/addDispositivo">         
            <div class="box-body">
                
            <div class="alert alert-danger alert-dismissible <?php if(isset($data)){if($data!=0){echo 'hidden';}}?>">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <h4><i class="icon fa fa-close"></i> Error!</h4>
                No se pudo ingresar el nuevo dispositivo, intente nuevamente.
            </div>
            
            <div class="alert alert-success alert-dismissible <?php if(isset($data)){if($data!=1){echo 'hidden';}}?>">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <h4><i class="icon fa fa-check"></i> Bien!</h4>
                Dispositivo agregado correctamente.
            </div>
                
              <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-connectdevelop"></i></span>
                <input name="nombre" type="text" class="form-control" placeholder="Nombre" required>
              </div>
              <br>
              <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-location-arrow"></i></span>
                <input name="localizacion" type="text" class="form-control" placeholder="Localización" required>
              </div>
              <br>
              <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-gears"></i></span>
                <select name="tipo" class="form-control" required>
                    <option valule="Foco">Foco</option>
                    <option valule="Puerta">Puerta</option>
                </select>
              </div>
              <br>
              <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-plug"></i></span>
                <input name="estado" type="number" class="form-control" placeholder="Estado" required>
              </div>
              <br>
              <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-bullseye"></i></span>
                <input name="valor" type="number" class="form-control" placeholder="Valor" required>
              </div>
              <!-- /input-group -->
            </div>
            <!-- /.box-body -->
            <div class="box-footer">
                <button type="submit" class="btn btn-primary center-block">Agregar</button>
            </div>
                <h4>
                    <a href="<?php echo base_url(); ?>administrar/dispositivos"><i class="fa fa-angle-double-left"></i> regresar</a>
                </h4>
            </form>                
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->