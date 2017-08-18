<?php
class Usuarios extends My_Controller
{
    function __construct()
    {
        parent::__construct();
        $this->load->model('usuarios_m');
        $this->load->model('des_encripta_m');
        if (isset($this->session->userdata['logged_in'])) {
            if($this->session->userdata['logged_in']['rol']=='Admin'){
            }
            else
                show_404();
        }
    }
    
    function index($mensaje = null)
    {
        $data['content_view'] = 'administrar/tusuarios_v';
        $data['data']['mensaje'] = $mensaje;
        if($mensaje === null) $data['data']['mensaje'] = 3;
        $data['data']['usuarios'] = $this->usuarios_m->get_usuarios(null);
        $this->template->global_template($data);
    }
    
    function info($id = null, $mensaje = null)
    {
        $data['content_view'] = 'administrar/tusuarios_v';
        $data['data']['mensaje'] = $mensaje;
        if($mensaje === null) $data['data']['mensaje'] = 3;
        $data['data']['usuarios'] = $this->usuarios_m->get_usuarios($id);
        $this->template->global_template($data);
    }
    
    function agregar()
    {
        $data['content_view'] = 'administrar/addusuario_v';
        $data['data'] = 3;
        $this->template->global_template($data);
    }
    
    function editar($id = null, $otro = null)
    {
        $data['content_view'] = 'administrar/updateusuario_v';
        $data['data']['mensaje'] = $otro;
        if($otro === null) $data['data']['mensaje'] = 3;
        if($id === null) $id='noid';
        
        $usuario = $this->usuarios_m->get_usuarios($id);
        if($usuario != null) $usuario[0]['password'] = $this->des_encripta_m->desencriptar($usuario[0]['password']);
        $data['data']['usuario'] = $usuario;
        $this->template->global_template($data);
    }
    
    public function eliminar($id = null)
    {
        $mensaje = 0;
        if($this->usuarios_m->eliminarUsuario($id) == 1) {
            $mensaje = 1;           
        }
        header('location: '.base_url().'/administrar/usuarios/index/'.$mensaje);
    }
        
    public function addUsuario()
    {
        $this->load->helper('form');
        
        $data['content_view'] = 'administrar/addusuario_v';
        $data['data'] = 0;     
        if($this->usuarios_m->agregarUsuario() == 1) {
            $data['data'] = 1;           
        }
        $this->template->global_template($data); 
        //$this->load->view('news/success');
    }
    
    public function updateUsuario()
    {
        $this->load->helper('form');
        $id = $this->input->post('id');
        $mensaje = 0;
        if($this->usuarios_m->actualizarUsuario() == 1) {
            $mensaje = 1;           
        }
        header('location: editar/'.$id.'/'.$mensaje);
    }
}