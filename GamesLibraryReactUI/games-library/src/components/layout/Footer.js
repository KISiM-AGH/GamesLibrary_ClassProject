import React from "react";
import {
  Box,
  Container
} from "./FooterStyles";

import classes from './Footer.module.css';

function Footer() {
  return (
    <footer className={classes.footer}>
      <p style={{color: "white"}}>  Authors: Piotr Apriasz, Patryk Bombiński</p>
    </footer>
  );
}

export default Footer;