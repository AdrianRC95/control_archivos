<?php
class Login_m extends CI_Model {

    public function __construct()
    {
        $this->load->database();
        $this->load->model('administrar/des_encripta_m');
    }
    
    public function validarUsuario()
    {
        $this->load->helper('url');

        $data = array(
            'email' => $this->input->post('email'),
            'password' => $this->des_encripta_m->encriptar($this->input->post('pass'))
        );
        
        $query = $this->db->get_where('usuario', $data);
        $result = $query->row_array();
        
        if(!empty($result))
        {
            $this->session->userdata['logged_in']['id'] = $result['id_usuario'];
            $this->session->userdata['logged_in']['username'] = $result['nombre'];
            $this->session->userdata['logged_in']['email'] = $result['email'];
            $this->session->userdata['logged_in']['rol'] = $result['rol'];
            return true;
        }
        else {
            return false;
        }
    }
    
    public function cerrarSesion()
    {
        $this->session->sess_destroy();
    }
}

