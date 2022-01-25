import styled from 'styled-components';

export const Box = styled.div`
  padding: 10px 100px;
  background: black;
  position: absolute;
  bottom: 0;
  width: 100%;
  height: 8%;
  
   
  @media (max-width: 1000px) {
    padding: 0 300px;
  }
`;

export const Container = styled.div`
    display: flex;
    justify-content: center;
    max-width: 1000px;
    margin: 0 auto;
`




