<?php
class Dispositivos extends My_Controller
{
    function __construct()
    {
        parent::__construct();
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
        $data['content_view'] = 'administrar/tdispositivos_v';
        $data['data']['mensaje'] = $mensaje;
        if($mensaje === null) $data['data']['mensaje'] = 3;
        $data['data']['dispositivos'] = $this->dispositivos_m->get_dispositivos(null);
        $this->template->global_template($data);      
    }
    
    function info($id = null, $mensaje = null)
    {
        $data['content_view'] = 'administrar/tdispositivos_v';
        $data['data']['mensaje'] = $mensaje;
        if($mensaje === null) $data['data']['mensaje'] = 3;
        $data['data']['dispositivos'] = $this->dispositivos_m->get_dispositivos($id);
        $this->template->global_template($data);  
    }
    
    function agregar()
    {
        $data['content_view'] = 'administrar/adddispositivo_v';
        $data['data'] = 3;
        $this->template->global_template($data);
    }
    
    function editar($id = null, $otro = null)
    {
        $data['content_view'] = 'administrar/updatedispositivo_v';
        $data['data']['mensaje'] = $otro;
        if($otro === null) $data['data']['mensaje'] = 3;
        if($id === null) $id='noid';
        $data['data']['dispositivo'] = $this->dispositivos_m->get_dispositivos($id);
        $this->template->global_template($data);
    }
    
    public function eliminar($id = null)
    {
        $mensaje = 0;
        if($this->dispositivos_m->eliminarDispositivo($id) == 1) {
            $mensaje = 1;           
        }
        header('location: '.base_url().'/administrar/dispositivos/index/'.$mensaje);
    }
        
    public function addDispositivo()
    {
        $this->load->helper('form');
        
        $data['content_view'] = 'administrar/adddispositivo_v';
        $data['data'] = 0;     
        if($this->dispositivos_m->agregarDispositivo() == 1) {
            $data['data'] = 1;           
        }
        $this->template->global_template($data); 
        //$this->load->view('news/success');
    }
    
    public function updateDispositivo()
    {
        $this->load->helper('form');
        $id = $this->input->post('id');
        $mensaje = 0;
        if($this->dispositivos_m->actualizarDispositivo() == 1) {
            $mensaje = 1;           
        }
        header('location: editar/'.$id.'/'.$mensaje);
    }
}