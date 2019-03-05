import React from 'react';
import { Col, Row, Container } from 'react-bootstrap';
import NavMenu from './NavMenu';

export default props => (
  <Container fluid>
    <Row>
      <Col sm={3}>
        <NavMenu />
      </Col>
      <Col sm={9}>
        {props.children}
      </Col>
    </Row>
  </Container>
);
