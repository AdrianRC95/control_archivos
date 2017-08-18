<?php

class Asociacion extends My_Controller
{
    function __construct()
    {
        parent::__construct();
        $this->load->model('asociacion_m');
        $this->load->model('usuarios_m');
        $this->load->model('dispositivos_m');
        if (isset($this->session->userdata['logged_in'])) {
            if($this->session->userdata['logged_in']['rol']=='Admin'){
            }
            else
                show_404();
        }
    }
    
    function index($mensaje = null)
    {   
        $data['content_view'] = 'administrar/tasociacion_v';
        $data['data']['mensaje'] = $mensaje;
        if($mensaje === null) $data['data']['mensaje'] = 3;
        $data['data']['asociacion'] = $this->asociacion_m->get_asociacion();
        $this->template->global_template($data);
    }
    
    function agregar()
    {
        $data['content_view'] = 'administrar/addasociacion_v';
        $data['data']['mensaje'] = 3;
        $data['data']['usuarios'] = $this->usuarios_m->get_usuarios(null);
        $data['data']['dispositivos'] = $this->dispositivos_m->get_dispositivos(null);
        $this->template->global_template($data);
    }
    
    public function addAsociacion()
    {
        $this->load->helper('form');
        
        $data['content_view'] = 'administrar/addasociacion_v';
        $data['data']['mensaje'] = $this->asociacion_m->nuevaAsociacion();
        $data['data']['usuarios'] = $this->usuarios_m->get_usuarios(null);
        $data['data']['dispositivos'] = $this->dispositivos_m->get_dispositivos(null);
        $this->template->global_template($data); 
        //$this->load->view('news/success');
    }
    
    public function eliminar($id = null)
    {
        $mensaje = 0;
        if($this->asociacion_m->eliminarAsociacion($id) == 1) {
            $mensaje = 1;           
        }
        header('location: '.base_url().'/administrar/asociacion/index/'.$mensaje);
    }
}