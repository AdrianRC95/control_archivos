<!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Dispositivo
        <small>.</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="#">Administrar</a></li>
        <li class="active">Editar Dispositivo</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="row center-block">
        <div class="col-md-6">
                <!-- Input addon -->
            <div class="box box-info">
            <div class="box-header with-border">
              <h3 class="box-title">Editar Dispositivo</h3>
            </div>
            <!-- form start -->
            <form role="form" method="post" action="<?php echo base_url(); ?>administrar/dispositivos/updateDispositivo">         
            <div class="box-body">
                
            <div class="alert alert-danger alert-dismissible <?php if(isset($data['mensaje'])){if($data['mensaje']!=0){echo 'hidden';}}?>">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <h4><i class="icon fa fa-close"></i> Error!</h4>
                Datos no actualizados, intente nuevamente.
            </div>
            
            <div class="alert alert-success alert-dismissible <?php if(isset($data['mensaje'])){if($data['mensaje']!=1){echo 'hidden';}}?>">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <h4><i class="icon fa fa-check"></i> Bien!</h4>
                Dispositivo actualizado correctamente.
            </div>
                
            <div class="alert alert-danger alert-dismissible <?php if(isset($data['dispositivo'])){if($data['dispositivo']!=null){echo 'hidden';}}?>">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <h4><i class="icon fa fa-close"></i> Error!</h4>
                No se encontró información del dispositivo.
            </div>
            <?php if(!empty($data['dispositivo'])){ $dispositivo = $data['dispositivo'][0];?>
            <div class="input-group hidden"> 
                <span class="input-group-addon"><i class="fa fa-user"></i></span>
                <input name="id" type="text" value="<?php echo $dispositivo['id_dispositivo']; ?>" 
                       class="form-control" placeholder="Id" required>
            </div>
            <br>                
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-connectdevelop"></i></span>
                <input name="nombre" type="text" value="<?php echo $dispositivo['nombre']; ?>" 
                       class="form-control" placeholder="Nombre" required>
            </div>
            <br>
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-location-arrow"></i></span>
                <input name="localizacion" type="text" value="<?php echo $dispositivo['localizacion']; ?>"
                       class="form-control" placeholder="Localización" required>
            </div>
            <br>
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-gears"></i></span>
                <select name="tipo" class="form-control" required>
                    <option value="Foco" <?php echo ($dispositivo['tipo']=='Foco')?'selected':''; ?> >Foco</option>
                    <option value="Puerta" <?php echo ($dispositivo['tipo']=='Puerta')?'selected':''; ?> >Puerta</option>
                </select>
            </div>
            <br>
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-plug"></i></span>
                <input name="estado" type="number" value="<?php echo $dispositivo['estado']; ?>" 
                       class="form-control" placeholder="Estado" required>
            </div>
            <br>
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-bullseye"></i></span>
                <input name="valor" type="number" value="<?php echo $dispositivo['valor']; ?>" 
                       class="form-control" placeholder="Valor" required>
            </div>
            <br>
            <button type="submit" class="btn btn-primary center-block">Actualizar</button>
            <!-- /input-group -->
            <?php } ?>    
            </div>
            <!-- /.box-body -->
            <div class="box-footer">
                <h4>
                    <a href="<?php echo base_url(); ?>administrar/dispositivos"><i class="fa fa-angle-double-left"></i> regresar</a>
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