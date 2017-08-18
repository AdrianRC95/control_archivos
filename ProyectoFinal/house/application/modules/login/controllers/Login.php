<?php
class Login extends My_Controller
{
    function __construct()
    {
        parent::__construct();
        $this->load->model('login_m');
    }
    
    function index()
    {
        $data['data'] = 0;
        $this->load->view('login/login_v',$data);
    }
    
    function validar()
    {
        $this->load->helper('form');
        if($this->login_m->validarUsuario())
        {
            header('location: '.base_url().'home');
            //$data['content_view'] = 'home/home_v';
            //$data['data'] = null;
            //$this->template->global_template($data);
        }
        else {
            $data['data'] = 1;
            $this->load->view('login/login_v',$data);            
        }
    }
    
    function salir()
    {
        $this->login_m->cerrarSesion();
        $data['data'] = 0;
        $this->load->view('login/login_v',$data);        
    }
}