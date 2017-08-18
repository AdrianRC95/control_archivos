<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        Dashboard
    <small>
    <a id="btnConexion" class="btn btn-danger" onclick="connectionToggle(<?php echo '\''.$this->session->userdata['logged_in']['email'].'\''; ?>);">Offline...</a></small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="#">Dashboard</a></li>
        <li class="active">General</li>
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
                <div class="box-body">
                    <?php if(isset($data)) { foreach ($data as $dispositivo): ?>            
                    <!-- col -->
                    <div class="col-md-3">
                      <div class="box box-success box-solid">
                        <div class="box-header with-border">
                          <h3 class="box-title"><?php echo $dispositivo['nombre']; ?></h3>

                          <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                            </button>
                          </div>
                          <!-- /.box-tools -->
                        </div>
                        <!-- /.box-header -->
                        <?php if($dispositivo['tipo']=='Foco') { ?>
                        <div class="box-body btn-foco" style="display: block;">
                            <a id="<?php echo $dispositivo["nombre"]; ?>" class="btn center-block cero" onclick="publish(this)">
                                <i class="fa fa-lightbulb-o low"></i> 
                            </a>
                            <span class="center-block"><?php echo $dispositivo['localizacion']; ?></span>
                        </div>
                        <?php } else if($dispositivo['tipo']=='Puerta') { ?>
                        <div class="box-body btn-puerta" style="display: block;">
                            <a id="<?php echo $dispositivo["nombre"]; ?>" class="btn center-block cero" onclick="publish(this);">
                                <img class="hidden" src="<?php echo base_url(); ?>assets/bootstrap/img/opened-door.png">
                                <img class="" src="<?php echo base_url(); ?>assets/bootstrap/img/closed-door.png">
                            </a>
                            <span class="center-block"><?php echo $dispositivo['localizacion']; ?></span>
                        </div>
                        <?php } ?>
                        <!-- /.box-body -->
                      </div>
                      <!-- /.box -->
                    </div>
                    <!-- /.col -->
                    <?php endforeach; }?>
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
<script src="<?php echo base_url();?>assets/plugins/mqtt/paho-mqtt.js"></script>
<script src="<?php echo base_url();?>assets/plugins/mqtt/utility.js"></script>



