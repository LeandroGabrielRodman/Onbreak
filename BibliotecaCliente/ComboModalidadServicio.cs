
        private OnBreakEntities1 bdd = new OnBreakEntities1();
        public List<ModalidadServicio> ModServ(int IdTpEvnto)
        {
            try
            {
                var lis = bdd.ModalidadServicio.ToList();
                var x = from TpEvnto in bdd.TipoEvento
                        join ModSer in bdd.ModalidadServicio
                            on TpEvnto.IdTipoEvento equals ModSer.IdTipoEvento
                        where TpEvnto.IdTipoEvento == IdTpEvnto
                        select new ModalidadServicio()
                        {
                            IdModalidad=ModSer.IdModalidad,
                            IdTipoEvento=TpEvnto.IdTipoEvento,
                            Nombre=ModSer.Nombre,
                            ValorBase=ModSer.ValorBase,
                            PersonalBase=ModSer.PersonalBase,
                        };
                return x.ToList();     
            }
            catch (Exception ex)
            {

                return null; 
            }
        }
        public override string ToString()
        {
            return Nombre.Trim();
        }
    }
}
